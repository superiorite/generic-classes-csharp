/*Напишите обобщенный класс, который может хранить 
 * в массиве объекты любого типа. Кроме того, 
 * данный класс должен иметь методы для добавления 
 * данных в массив, удаления из массива, получения 
 * элемента из массива по индексу и метод, возвращающий 
 * длину массива.

Для упрощения работы можно пересоздавать массив при 
каждой операции добавления и удаления*/


MyClass<int> myclass = new MyClass<int>();

myclass.Add(1);
myclass.Add(2);
myclass.Add(3);

for (int i = 0; i < myclass.Count(); i++)
{
    Console.WriteLine(myclass.GetItem(i)); // 1 2 3
}

myclass.Remove(5);
myclass.Remove(3);

for (int i = 0; i < myclass.Count(); i++)
{
    Console.WriteLine(myclass.GetItem(i)); // 1 2
}


class MyClass<P>
{
    P[] data;

    public MyClass()
    {   
        data = new P[0];
    }
    
    //добавление данных
    public void Add(P obj)
    {   
        P[] newData = new P[data.Length + 1];
        for (int i = 0; i < data.Length; i++)
        {
            newData[i] = data[i];
        }
        newData[data.Length] = obj;
        data = newData; 
    }
    //удаление данных - удаляем первое вхождение элемента при его наличии
    public void Remove(P obj)
    {
        //находим индекс элемента
        int index = -1;
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Equals(obj))
            {
                index = i;
                break;
            }
        }
        if (index > -1)
        {
            P[] newData = new P[data.Length - 1];
            for (int i = 0, j = 0; i < data.Length; i++)
            {
                if (i == index) continue;
                newData[j] = data[i];
                j++;
            }
            data = newData;
        }
    }

    // получение элемента по индексу
    public P GetItem(int index)
    {
        if (index > -1 && index < data.Length)
        {
            return data[index];
        }
        else
            throw new IndexOutOfRangeException();
    }
    public int Count()
    {
        return data.Length;
    }
}
