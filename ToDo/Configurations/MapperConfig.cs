using System;
using AutoMapper;
using ToDo.Datas;
using ToDo.Models.Todo;
using ToDo.Models.TodoType;
using ToDo.Models.User;

namespace ToDo.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<TodoType, CreateTodoTypeDto>().ReverseMap();
            CreateMap<TodoType, UpdateTodoTypeDto>().ReverseMap();
            CreateMap<TodoType, TodoTypeDto>().ReverseMap();
            CreateMap<TodoType, TodoTypeWithTodoDto>().ReverseMap();

            CreateMap<Todo, CreateTodoDto>().ReverseMap();
            CreateMap<Todo, UpdateTodoDto>().ReverseMap();
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<Todo, TodoWithTodoTypeDto>().ReverseMap();

            CreateMap<User, RegisterDto>().ReverseMap();
        }
	}
}

