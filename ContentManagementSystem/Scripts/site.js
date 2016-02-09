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
            $( 'header' ).addClass( 'always-open' ).removeClass( 'open' );
        }

        $( '#body' ).css( {
            'padding-bottom': $( 'footer' ).outerHeight(),
            'padding-top': $( '.page-header' ).outerHeight(),
        } );
    }

    function handleMenuLinkClick()
    {
        $( this ).parent().toggleClass( 'open' );
    }

    init();
}