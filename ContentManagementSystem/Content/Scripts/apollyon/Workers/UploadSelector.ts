﻿module apollyon
{
    export class UploadSelector
    {
        private _element: JQuery;
        private _searchBox: JQuery;
        private _uploadOptions: JQuery;
        private _uploadSelectedCallback: Function;
        private _timeout: number;
        private _isLoaded: boolean = false;

        constructor( options )
        {
            options = options || {};

            if ( typeof options.uploadSelected === "function" )
            {
                this._uploadSelectedCallback = options.uploadSelected;
            }
            else
            {
                this._uploadSelectedCallback = function () { };
            }

            if ( $( "#uploadSelector" ).length > 0 )
            {
                this.initialise();
            }
        }

        /**
         * Opens the upload selector modal.
         */
        public open(): void
        {
            var that = this;

            function openModal()
            {
                that._searchBox.val( "" );
                that._uploadOptions.empty()

                that._element.bgmodal( "open" );
            }

            if ( this._isLoaded )
            {
                openModal();
            }
            else
            {
                $.get( "/admin/uploads/selector", function ( data )
                {
                    $( "body" ).append( data );

                    that.initialise();

                    openModal();
                });
            }
        }

        /**
         * Closes the upload selector modal.
         */
        public close()
        {
            this._element.bgmodal( "close" );
        }

        /**
         * Initialises the upload selector object.
         */
        private initialise(): void
        {
            this._element = $( "#uploadSelector" ).bgmodal();
            this._searchBox = this._element.find( "#UploadSelectorSearchBox" );
            this._uploadOptions = this._element.find( "#uploadOptions" );

            this.attachEvents();

            this._isLoaded = true;
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
                that.close();
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
                    options.append( "<li data-upload-id=\"" + upload.uploadId + "\"><a href=\"javascript:void(0);\"><img src=\"" + upload.fileLocation + "\" /><p>" + upload.title + "</p></a></li>" );
                }
            });
        }
    }
}