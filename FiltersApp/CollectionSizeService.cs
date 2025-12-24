using System.Collections;

namespace FiltersApp;

internal sealed class CollectionSizeService
{
    public int GetSize(IEnumerable<int> hugeSizeItems)
    {
        if (hugeSizeItems is ICollection<int> collection)
        {
            return collection.Count;
        }

        if (hugeSizeItems is ICollection collectionNonGeneric)
        {
            return collectionNonGeneric.Count;
        }

        if (hugeSizeItems is IReadOnlyCollection<int> readOnlyCollection)
        {
            return readOnlyCollection.Count;
        }

        return hugeSizeItems.Count();
    }
}