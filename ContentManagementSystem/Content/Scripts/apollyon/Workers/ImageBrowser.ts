module apollyon
{
    type ImageBrowserCallback = ( urls: Array<string>, urlCount: Number ) => void;

    export class ImageBrowser
    {
        /**
         * Holds a reference to the open image browser window.
         */
        private _openWindow: Window;
        /**
         * Holds a reference to the callback method when the images have been selected.
         */
        private _callback: ImageBrowserCallback;

        constructor()
        {

        }

        /**
         * Opens a new browser window for selecting images from.
         * @param {ImageBrowserCallback} callback The method to call when the images have been selected and submitted.
         */
        public openBrowser( callback )
        {
            this._callback = callback;

            this._openWindow = window.open( window.location.origin + "/admin/imagebrowser/select", "image-browser", "height=640,width=1120" );
            this._openWindow.focus();
        }

        /**
         * Sends the urls of the selected images back to the callback method.
         * @param {Array<string>} urls The urls of the selected images.
         */
        public sendImages( urls )
        {
            this._callback( urls, urls.length );
            this._openWindow.close();

            this._openWindow = undefined;
            this._callback = undefined;
        }
    }
}