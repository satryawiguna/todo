using System;
using AutoMapper;
using ToDo.Datas;
using ToDo.Models.TodoType;

namespace ToDo.Configurations
{
	public class MapperConfig : Profile
	{
		public MapperConfig()
		{
			CreateMap<TodoType, CreateTodoTypeDto>().ReverseMap();
		}
	}
}

