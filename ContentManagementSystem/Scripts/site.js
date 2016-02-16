function Site()
{
    var that = this;

    this.contactForm = new Contact();
    this.notification = new Notification();
    this.animate = new Animations();

    function init()
    {
        attachEventHandlers();

        $( window ).resize();

        setTimeout(function ()
        {
            $( '#body' ).addClass( 'on' );
        }, 600 )
    }

    function attachEventHandlers()
    {
        $( window ).on( 'resize', handleResize );
        $( '.menu-link' ).on( 'click', handleMenuLinkClick );
    }

    function handleResize()
    {
        if ( window.innerWidth < 960 )
        {
            $( 'header' ).removeClass( 'always-open' );
        }
        else
        {
            $( 'header' ).addClass( 'always-open' ).removeClass( 'open' ).removeClass( 'changing' );
        }

        $( '#body' ).css( {
            'padding-bottom': $( 'footer' ).outerHeight(),
            'padding-top': $( '.page-header' ).outerHeight(),
        } );
    }

    function handleMenuLinkClick()
    {
        var $parent = $( this ).parent();
        $parent.toggleClass( 'open' );

        if ( $parent.hasClass( 'open' ) == false )
        {
            $parent.addClass( 'changing' );

            setTimeout( function ()
            {
                $parent.addClass( 'changing' );
            }, 300 );
        }
    }

    init();
}