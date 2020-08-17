using System;

namespace src.CsharpBasicSkeleton.Items.Application
{
    public class ItemResponse
    {
        public Guid Id { get;}
        public string Name { get;}
        public bool IsCompleted { get;}
        
        public int Priority { get;}

        public ItemResponse(Guid id, string name, bool isCompleted, int priority)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
            Priority = priority;
        }
    }
}