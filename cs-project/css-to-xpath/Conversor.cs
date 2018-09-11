using Jint;
using System;

namespace tk.crazylab.csstoxpath
{
    /**
     * Class to convert CSS selector to Xpath
     */
    public class Conversor
    {
        // Instance for the singleton mode
        private static Conversor instance = null;
        // The Jint instance
        private Engine jsEngine = null;
        // Execution error event handler
        public event EventHandler<JavascriptErrorEventArgs> javascriptError;
        //Make class thread safe
        private static System.Object lockThisStatic = new System.Object();

        private System.Object lockThis = new System.Object();
        /**
         * Return a instance of the class
         * 
         * singleton indicate that it will always return the same instance
         */
        public static Conversor getInstance(bool singleton = true) {
            Conversor newInstance = null;
            lock (lockThisStatic) {
                if (singleton == true) {
                    if (instance == null) {
                        instance = new Conversor();
                    }
                    newInstance = instance;
                } else {
                    newInstance = new Conversor();
                }
            }
            return newInstance;
        }
        /**
         * Invoke the error delegate
         */
        public void OnJavascriptError(JavascriptErrorEventArgs error) {
            javascriptError?.Invoke(this, error);
        }
        /**
         * Constructor
         */
        private Conversor() {
            jsEngine = new Engine();
            jsEngine.Execute(JavascriptString.program);
        }
        /**
         * Do the conversion: receive the CSS selector to convert to Xpath
         */
        public string cssToXpath(string css) {
            lock (lockThis) {
                try {
                    return jsEngine.Invoke("cssToXpath", css).AsString();
                }
                catch (Exception ex) {
                    OnJavascriptError(new JavascriptErrorEventArgs() { e = ex });
                    return "";
                }
            }
        }
    }
}
