module apollyon
{
    export class EditorPopup
    {
        private _ckEditor: CKEDITOR.editor;
        private _callback: Function;

        constructor( elementId: string )
        {
            CKEDITOR.replace( elementId );
            this._ckEditor = CKEDITOR.instances[ elementId ];
            
            $( "#cancelColumnContent" ).on( "click", $.proxy( this.cancelModalChanges, this ) );
            $( "#acceptColumnContent" ).on( "click", $.proxy( this.acceptModalChanges, this ) );
            
            $( "#columnPopup" ).bgmodal(
            {
                autoOpen: false
            });
        }

        /**
         * Opens the CK Editor modal.
         * @param html The existing html to add to the editor.
         * @param callback Raised when the changes are accepted.
         */
        public openModal( html: string, callback: Function ): void
        {
            this._ckEditor.setData( html );
            this._callback = callback;

            $( "#columnPopup" ).bgmodal( "open" );
        }

        /**
         * Event handler for when the modal changes are accepted.
         */
        private acceptModalChanges(): void
        {
            this._callback.call( this, this._ckEditor.getData() );

            this.cancelModalChanges();
        }

        /**
         * Event handler for when the modal changes are declined.
         */
        private cancelModalChanges(): void
        {
            this._callback = null;

            $( "#columnPopup" ).bgmodal( "close" );
        }
    }
}