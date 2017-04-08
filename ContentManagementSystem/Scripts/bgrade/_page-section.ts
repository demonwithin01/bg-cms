module bgrade
{
    export abstract class PageSection
    {
        abstract init(): void;

        abstract name(): string;

        onResize( dim ): void
        {

        };
    }
}