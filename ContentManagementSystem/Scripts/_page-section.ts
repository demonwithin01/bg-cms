module Site
{
    export abstract class PageSection
    {
        abstract init(): void;

        onResize( dim ): void
        {

        };
    }
}