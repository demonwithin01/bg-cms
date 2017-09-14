﻿interface JQuery
{
    appendThen( content, callback ): JQuery;
    appendRender( content ): JQuery;
    bgmodal( options?: any ): JQuery;
    carousel( options: any ): JQuery;
    jsSocials( args: any ): JQuery;
    resizable( options: any ): JQuery;
    selectmenu( options?: any ): JQuery;
    spectrum( options: any ): JQuery;
}

module apollyon
{
    /**
     * Performs a JQuery append, then raises the callback method.
     * @param {JQuery | any[] | Element | DocumentFragment | Text | string} content The content to append to the current JQuery object.
     * @param {Function} callback The function that will be called once a reflow of the layout has been completed.
     */
    $.fn.appendThen = function ( content: JQuery | any[] | Element | DocumentFragment | Text | string, callback: Function )
    {
        this.append( content );

        var $this = this;

        this.get( 0 ).offsetHeight;

        callback.call( this );

        return this;
    }

    /**
     * Performs a JQuery append, the reflows the current JQuery object(s).
     * @param {JQuery | any[] | Element | DocumentFragment | Text | string} content The content to append to the current JQuery object.
     */
    $.fn.appendRender = function ( content: JQuery | any[] | Element | DocumentFragment | Text | string )
    {
        this.each( function ( index, element )
        {
            $( element ).append( content );

            element.offsetHeight;
        });

        return this;
    }
}