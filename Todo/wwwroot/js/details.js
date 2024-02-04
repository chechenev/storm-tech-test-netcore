const hideCompletedToggle = document.querySelector('#hideCompletedToggle');

const toggleHideTodoItems = () => {
    if (todoItems && todoItems.length > 0) {
        const completedItems = todoItems.filter(todo => todo.isDone);

        completedItems.forEach(todo => {
            const todoElement = document.querySelector('#item-' + todo.todoItemId);
            todoElement.style.display = hideCompletedToggle.checked ? 'none' : 'block';
        })
    }
}

hideCompletedToggle.addEventListener('change', toggleHideTodoItems);