

namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Helper function for <see cref="IconType"/> 
    /// </summary>
    public static class IconTypeExtensions
    {
        /// <summary>
        /// Convert a <see cref="IconType"/> to a fontawesome string
        /// </summary>
        /// <param name="type">the type to convert <param>
        /// <returns></returns>
        public static string ToFontAwesome(this IconType type)
        {
            //Return a fontawesome string base on the icon type
            switch (type)
            {

                case IconType.File:
                    return "\uf0f6";

                case IconType.Picture:                  
                    return "\uf1c5";

                    //If none found, return null
                default:
                    return null;
            }
        }
    }
}
