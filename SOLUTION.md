## Notes

| 2 | When todo items are displayed in browser in the details page, they are listed in an arbitrary order. Change `Views/TodoList/Detail.cshtml` so that items are listed by order of importance: `High`, `Medium`, `Low` |

I made changes in `Views/TodoList/Detail.cshtml`, when at the same time I could have done it in the `Todo/Controllers/TodoListController.cs` Controller. I made the changes in the View for two reasons:
1. It was specifiacily mentioned in the task
2. We might want to reuse "default" ordering in different places of the app

| 5 | On the details page, add an option to hide items that are marked as done. |

I thgouht about a few options here:
1. Add the logic on the frontend side
2. Add something like "isCompleted" to Model/Controller, pass it as a new variable

I chose first option (frontend side) to avoid unnecessary backend logic when it's only about UI part. So my idea is to render all todo items, serialize array to JS, and then filter completed todo items.