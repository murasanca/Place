// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("14N2cdVV+tPgi/XfVimWeLKN64W6GDYVKTemV8GOypSVCsaMYedeRs4ONUoaFTS9Cfl2BEOO9OvVushQprW3KemM0TbF0BDU4tYdvhxWd7t44W9UFgMnwa346Bq9EN7u+5/yhcI9o5ftLcNZIJv2IcuYUilsN6gLDR5NmRXaM9Bvu7q9W+lenFmT/VznVdb159rR3v1Rn1Eg2tbW1tLX1DJoKAmhdEADVA8lBYvT/lI7K5S+VdbY1+dV1t3VVdbW1x4jeu7tWuFNLx6bEUIv1jEFROnyUckAorvMMlb0DIAPjsI6gm/DFp7LafsJxZD7oAWVHlcrKBc+7q1GVQN6ZDe8M7VuDDctsFIJ2eA5F7KygrJlKJ42TrYwhWdXktRrNtXU1tfW");
        private static int[] order = new int[] { 8,3,6,9,10,11,10,8,13,9,13,11,13,13,14 };
        private static int key = 215;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
