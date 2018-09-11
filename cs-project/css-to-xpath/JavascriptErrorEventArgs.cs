using System;
using System.Collections.Generic;
using System.Text;

namespace tk.crazylab.csstoxpath {
    /**
     * Mensagem de erro passado para o callback do conversor
     */
    public class JavascriptErrorEventArgs : EventArgs
    {
        public Exception e = null;
    }
}
