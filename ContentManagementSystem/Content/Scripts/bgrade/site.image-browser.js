
function ImageBrowser()
{
    var that = this;
    var _openWindow = undefined;
    var _callback = undefined;

    this.openBrowser = function ($self, callback)
    {
        _callback = callback;

        _openWindow = window.open( window.location.origin + '/admin/imagebrowser/select', 'image-browser', 'height=640,width=1120' );
        _openWindow.focus();
    }

    this.sendImages = function (urls)
    {
        _callback( urls, urls.length );
        _openWindow.close();
        _openWindow = undefined;
        _callback = undefined;
    }
}

var IMAGEBROWSER = new ImageBrowser();