using Ardalis.Result;
using KG_CleanArchitecture.Core.ProjectAggregate;

namespace KG_CleanArchitecture.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
