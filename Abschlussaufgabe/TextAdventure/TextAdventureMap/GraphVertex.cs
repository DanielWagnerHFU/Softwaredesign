using System;
using System.Collections.Generic;

namespace TextAdventureMap
{
    public class GraphVertex<T>
    {
    private T dataElement;
    private LinkedList<GraphEdge<T>> neighbors;
    }
}