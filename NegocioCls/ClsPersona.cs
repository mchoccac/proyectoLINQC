using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NegocioCls
{
    public class ClsPersona
    {
        Db_persona_entDataContext mDb = new Db_persona_entDataContext();

        public void insert(String nombre, String telefono) {
            persona per = new persona();
            per.nombre = nombre;
            per.telefono = Int32.Parse(telefono);
            mDb.personas.InsertOnSubmit(per);
            mDb.SubmitChanges();
        }

        public void delete(int id) {
            var m_update = from x in mDb.personas where x.id == id select x;
            foreach (persona per_ in m_update) {
                mDb.personas.DeleteOnSubmit(per_);
            }
            mDb.SubmitChanges();
        }

        public void selectAll(ListBox lista) {
            lista.Items.Clear();
            var m_consulta = from x in mDb.personas select x;
            foreach (persona per_ in m_consulta) {
                lista.Items.Add(per_.id + " - " + per_.nombre + " - " + per_.telefono);
            }
        }


        public void selectAll(ComboBox lista)
        {
            lista.Items.Clear();
            var m_consulta = from x in mDb.personas select x;
            foreach (persona per_ in m_consulta)
            {
                lista.Items.Add(per_.id + " - " + per_.nombre);
            }
            lista.SelectedIndex = 0;
        }

        public void update(String nombre, String telefono, int id) {
            var m_update = (from x in mDb.personas where x.id == id select x).First();
            m_update.nombre = nombre;
            m_update.telefono = Int32.Parse(telefono);
            mDb.SubmitChanges();
        }

        public void loadform(String id,  TextBox nombre, TextBox telefono) {
            var m_select = from x in mDb.personas where x.id == Int32.Parse(id) select x;
            foreach (persona p in m_select) {
                nombre.Text = p.nombre;
                telefono.Text = p.telefono.ToString();
            }
        }

    }
}
