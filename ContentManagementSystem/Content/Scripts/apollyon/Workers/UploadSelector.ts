module apollyon
{
    export class UploadSelector
    {
        private _element: JQuery;
        private _searchBox: JQuery;
        private _uploadOptions: JQuery;
        private _uploadSelectedCallback: Function;
        private _timeout: number;

        constructor()
        {
            this._element = $( "#uploadSelector" ).bgmodal();
            this._searchBox = this._element.find( "#UploadSelectorSearchBox" );
            this._uploadOptions = this._element.find( "#uploadOptions" );

            this.attachEvents();
        }

        /**
         * Opens the upload selector modal.
         */
        public open(): void
        {
            this._searchBox.val( "" );
            this._uploadOptions.empty()

            this._element.bgmodal( "open" );
        }

        /**
         * Attaches the events required by the upload selector.
         */
        private attachEvents(): void
        {
            var that = this;

            // Cancel upload selection handler.
            this._element.find( ".cancel-modal" ).on( "click", function ()
            {
                that._element.bgmodal( "close" );
            });

            // Searchbox key up handler.
            this._searchBox.on( "keyup", function ()
            {
                clearTimeout( that._timeout );

                if ( $( this ).val().length > 2 )
                {
                    that._timeout = setTimeout( function ()
                    {
                        that.performSearch();
                    }, 500 );
                }
            });

            // Upload selected handler.
            this._uploadOptions.on( "click", "li", function ()
            {
                var element = $( this );
                var data = {
                    uploadId: element.data( "upload-id" ),
                    imgSrc: element.find( "img" ).attr( "src" ),
                    title: element.find( "p" ).text()
                };

                that._uploadSelectedCallback.call( that, data );
            });
        }

        /**
         * Performs a search for matching upload titles.
         */
        private performSearch(): void
        {
            var that = this;

            $.post( "/admin/search/uploads", { term: this._searchBox.val() }, function ( data )
            {
                var options = that._uploadOptions.empty();

                for ( var i = 0; i < data.uploads.length; i++ )
                {
                    var upload = data.uploads[ i ];
                    options.append( "<li data-upload-id=\"" + upload.uploadId + "\"><a href=\"javascript:void(0);\" onclick=\"selectUpload( $(this) );\"><img src=\"" + upload.fileLocation + "\" /><p>" + upload.title + "</p></a></li>" );
                }
            });
        }
    }
}