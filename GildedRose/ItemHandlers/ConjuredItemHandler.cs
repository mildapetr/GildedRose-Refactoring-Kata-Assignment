namespace GildedRoseKata.ItemHandlers
{
    // I chose to inherit from CommomItemHandler rather than from IItemHandler to avoid duplicating behaviour,
    // because the only thing this class and CommomItemHandler differ in is the quality decrease step (constant).
    // However, if there was anything else, I doubt I would've gone that route.
    public class ConjuredItemHandler : CommonItemHandler
    {
        public const int QualityDecreaseStepMultiplier = 2;

        public ConjuredItemHandler() : base (DefaultQualityDecreaseStep * QualityDecreaseStepMultiplier) { }
    }
}
