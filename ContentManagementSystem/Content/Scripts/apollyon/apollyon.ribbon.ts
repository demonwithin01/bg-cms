module apollyon
{
    export class Ribbon
    {

        constructor()
        {

        }

        public onWindowResize()
        {
            $( ".ribbon-item > .b-grid" ).each( function ()
            {
                var minHeight = 0;

                var $children = $( this ).children();

                if ( $children.length < 2 )
                {
                    return;
                }

                $children.each( function ()
                {
                    var el = $( this ).children().get( 0 );

                    el.style.minHeight = "0";

                    var height = el.offsetHeight;

                    if ( height > minHeight )
                    {
                        minHeight = height;
                    }
                });

                var height = minHeight + "px";

                $children.each( function ()
                {
                    var el = $( this ).children().get( 0 );

                    el.style.minHeight = height;
                });
            } );
        }
        
        public onMainContentScroll()
        {
            console.log( "scroll Background" );
        }

        public initialise()
        {
            this.onWindowResize();
        }

    }
}