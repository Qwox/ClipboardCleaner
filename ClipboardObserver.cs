using System.Runtime.InteropServices;

namespace ClipboardCleaner
{
    public class ClipboardObserver : NativeWindow
    {
        private const int WM_DESTROY = 0x2;
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        public event ClipboardChangedHandler? ClipboardChanged;
        public delegate void ClipboardChangedHandler();

        public bool IsListening
        {
            get; private set;
        }

        public ClipboardObserver()
        {
            CreateHandle(new CreateParams());
        }

        public ClipboardObserver(IntPtr parentWindowHandle)
        {
            CreateHandle(new CreateParams() { Parent = parentWindowHandle });
            if(AddClipboardFormatListener(Handle))
            {
                IsListening = true;
            }
            else
            {
                throw new Exception("Exception occurred at: AddClipboardFormatListener");
            }
        }

        public bool AddClipboardListener()
        {
            if (!IsListening)
            {
                bool result = AddClipboardFormatListener(Handle);
                if (result)
                {
                    IsListening = true;
                }
                return result;
            }
            return false;
        }

        public bool RemoveClipboardListener()
        {
            if(IsListening)
            {
                bool result = RemoveClipboardFormatListener(Handle);
                if(result)
                {
                    IsListening = false;
                }
                return result;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CLIPBOARDUPDATE:
                    ClipboardChanged?.Invoke();
                    break;

                case WM_DESTROY:
                    if(RemoveClipboardFormatListener(Handle))
                    {
                        IsListening = false;
                    }
                    break;
            }

            base.WndProc(ref m);
        }
    }
}
