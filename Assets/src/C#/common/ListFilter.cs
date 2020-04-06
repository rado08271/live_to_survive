using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {
	public class ListFilter<T> {
        public virtual IList<T> fillList(T typeOfObject, int size) {
            IList<T> listToFill = new List<T>();

            for (int i = 0; i < size; i++) {
                listToFill.Add(typeOfObject);
            }

            return listToFill;
        }
	}
}
