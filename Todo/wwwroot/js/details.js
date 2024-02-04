const hideCompletedToggle = document.querySelector('#hideCompletedToggle');
const createNewItemButton = document.querySelector('#createNewItemButton');
const createNewItemFormWrapper = document.querySelector('.createTodo-wrapper');
const createNewItemForm = document.querySelector('[name="createTodo"]');

const mapImportanceToEnum = {
    'High': 0,
    'Medium': 1,
    'Low': 2
}

const toggleHideTodoItems = () => {
    if (todoItems && todoItems.length > 0) {
        const completedItems = todoItems.filter(todo => todo.isDone);

        completedItems.forEach(todo => {
            const todoElement = document.querySelector('#item-' + todo.todoItemId);
            todoElement.style.display = hideCompletedToggle.checked ? 'none' : 'block';
        })
    }
}

const createNewItemButtonClickHandler = () => {
    if (createNewItemFormWrapper) {
        createNewItemFormWrapper.classList.toggle('createTodo-wrapper__visible');
    }
}

const createNewItemFormSubmitHandler = async (e) => {
    e.preventDefault();
    const formData = {
        TodoListTitle: document.getElementById('TodoItemCreateFields_TodoListTitle').value,
        Title: document.getElementById('TodoItemCreateFields_Title').value,
        ResponsiblePartyId: document.getElementById('TodoItemCreateFields_ResponsiblePartyId').value,
        Importance: mapImportanceToEnum[document.getElementById('TodoItemCreateFields_Importance').value],
        TodoListId: document.getElementById('TodoItemCreateFields_TodoListId').value
    }

    console.log('formData', formData)

    if (formData.Title.trim() !== '') {
        try {
            const response = await fetch("/api/TodoItemApi", {
              method: "POST",
              headers: {
                'Content-Type': 'application/json'
              },
              body: JSON.stringify(formData),
            });
            const result = await response.json();
            console.log("Success:", result);
          } 
          catch (error) {
            console.error("Error:", error);
          }
    }

}

createNewItemButton.addEventListener('click', createNewItemButtonClickHandler);
hideCompletedToggle.addEventListener('change', toggleHideTodoItems);
createNewItemForm.addEventListener('submit', createNewItemFormSubmitHandler)