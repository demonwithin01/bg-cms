var _site = _site || {};

module apollyon
{
    export class Contact extends PageSection
    {
        
        public init(): void
        {
            console.log( "initialised Contact" );
        }

        public name(): string
        {
            return "ContactMe";
        }

        public formResult( data: any ): void
        {
            if ( data.success )
            {
                _site.showNotification( notificationType.success, data.message );
            }
            else
            {

            }
        }
    }
}