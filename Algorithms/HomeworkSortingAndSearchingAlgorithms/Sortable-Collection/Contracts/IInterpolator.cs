namespace SortingLab.Contracts
{
    using System.Collections.Generic;

    public interface IInterpolator<T>
    {
        int Interpolate(IList<T> list, int high, int low, T needle);
    }
}
