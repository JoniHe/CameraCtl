using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tools.Func.WinFormCtl
{

    public class CbbDataBinder
    {
        public System.Windows.Forms.ComboBox ComboBox { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }

        public CbbDataBinder(System.Windows.Forms.ComboBox cbb)
        {
            ComboBox = cbb;
        }

        //绑定枚举数据
        public void DataBindingEnum<T>(T t)
        {
            //使用Enum.GetValues（）方法，将枚举元素的名称赋值给控件。
            ComboBox.DataSource = Enum.GetValues(t.GetType());
        }

        //绑枚举数据展示description
        public void DataBindingEnumDesc<T>()
        {
            ComboBox.DisplayMember = "Value";
            ComboBox.ValueMember = "Key";
            ComboBox.DataSource = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<T, string>(
                    p,
                    (p.GetType().GetField(p.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute)?.Description ?? p.ToString()
                    ))
                    .ToList(); ;
        }

        public  static void DataBindingEnumDesc<T>(System.Windows.Forms.ComboBox combox)
        {
            combox.DisplayMember = "Value";
            combox.ValueMember = "Key";
            combox.DataSource = Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<T, string>(
                    p,
                    (p.GetType().GetField(p.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute)?.Description ?? p.ToString()
                    ))
                    .ToList(); ;
        }


        //绑定对象集合
        //创建一个对象类型的List集合。并将集合赋值给控件的DataSource（数据源），并给控件的DisplayMember属性和ValueMember属性赋值
        public void DataBindingObject(List<Data> datas)
        {

            ComboBox.DataSource = datas;
            ComboBox.DisplayMember = "Name";
            ComboBox.ValueMember = "Id";
        }




    }

    public struct Data
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
    }
}

