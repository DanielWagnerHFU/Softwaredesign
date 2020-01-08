using System;
using System.Collections.Generic;

namespace TextAdventureMap
{
    public class GraphVertex<T>
    {
    protected T dataElement;
    protected LinkedList<GraphEdge<T>> neighbors;
    }
}