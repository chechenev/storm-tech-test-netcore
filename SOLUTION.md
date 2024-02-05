## Notes

| 5 | On the details page, add an option to hide items that are marked as done. |

I thgouht about a few options here:
1. Add the logic on the frontend side
2. Add something like "isCompleted" to Model/Controller, pass it as a new variable

I chose first option (frontend side) to avoid unnecessary backend logic when it's only about UI part. So my idea is to render all todo items, serialize array to JS, and then filter completed todo items.

| 9 | The process of adding items to a list is pretty clunky; the user has to go to a new page, fill in a form, then go back to the list detail page. It would be easier for the user to do all that on the list detail page. Replace the "Add New Item" link with UI that allows creation of items without navigating away from the detail page. You will need to use Javascript and an API that you create. |

I created a new `/api/` endpoint for POST request that I trigger on FE side.
There is one specific thing that I don't like - after you create a new todo item async you still need to reload the page to reflect new changes. If I have more time to work on it I would do it like that:
- ordering/sorting happen on BE side, so I just need to know what is the current ordering option
- create new HTML element on FE side, find correct place in the array of sorted items and add it there