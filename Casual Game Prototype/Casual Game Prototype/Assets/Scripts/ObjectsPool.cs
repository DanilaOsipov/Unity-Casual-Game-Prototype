using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ObjectsPool
{
    private static Queue<ObjectsPoolItem> items;

    public static bool IsEmpty => items.Count == 0;

    public static void Initialize(IEnumerable<ObjectsPoolItem> items)
    {
        ObjectsPool.items = new Queue<ObjectsPoolItem>(items);
    }

    public static ObjectsPoolItem GetItem()
    {
        return items.Dequeue();
    }

    public static void AddItem(ObjectsPoolItem item)
    {
        items.Enqueue(item);
    }
}

