using System;
using System.Text;

namespace PrimeChainFinder
{
    public class Chain
    {

        #region Fields
        public ulong? FirstElement { get; private set; }
        public ulong? FirstElementDisplacement { get; private set; }
        public ulong? LastElement { get; private set; }
        public ulong? LastElementDisplacement { get; private set; }
        public ulong? Length { get; private set; }
        #endregion

        #region Constructor
        public Chain(ulong firstElement, ulong firstElementDisplacement)
        {
            AddElement(firstElement, firstElementDisplacement);
        }
        #endregion

        #region Public methods

        #region Add element to chain
        public void AddElement(ulong element, ulong displacement)
        {
            if (FirstElement == null)
            {
                FirstElement = LastElement = element;
                FirstElementDisplacement = LastElementDisplacement = displacement;
                Length = 1;
            }
            else
            {
                if ((element > LastElement) && (displacement > LastElementDisplacement))
                {
                    LastElement = element;
                    LastElementDisplacement = displacement;
                    Length++;
                }
                else
                {
                    throw new ArgumentException("This number is not in chain");
                }
            }
        }
        #endregion

        #region ToString override
        public override string ToString()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("First element:" + FirstElement + Environment.NewLine);
            strb.Append("First element displacement:" + FirstElementDisplacement + Environment.NewLine);
            strb.Append("Last element:" + LastElement + Environment.NewLine);
            strb.Append("Last element displacement:" + LastElementDisplacement + Environment.NewLine);
            strb.Append("Chain length:" + Length);
            string str = strb.ToString();
            return str;
        }
        #endregion

        #endregion

    }
}
