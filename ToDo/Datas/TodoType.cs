namespace ToDo.Datas
{
    public class TodoType
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public virtual IList<Todo> Todos { get; set; }
    }
}