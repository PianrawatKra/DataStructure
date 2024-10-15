namespace Stacks
{
    public interface Stack
    {
        bool isEmpty();
        int size();
        void push(object e);
        object pop();
        object peek();
    }
}