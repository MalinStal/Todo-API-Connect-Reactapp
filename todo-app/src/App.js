import { useState, useEffect } from 'react';
import './App.css';

function App() {
//idet i todo verkar inte ha någon inverkan 
  const [todo, setTodo] = useState({id: 1,title: "", description: "", completed: false});
  const [list, setList] = useState([]);


  useEffect(() => {
    fetch("http://localhost:5213/todo/get")
    .then(res => res.json())
    .then(setList);
  },[])

 const handelSubmit = (e) => {
  e.preventDefault();
  fetch("http://localhost:5213/todo/add", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      title: todo.title,
      description: todo.description
    })
  })
  .then(res => res.json())
  .then(todos => {
    setList([...list, todos]);
    setTodo({ title: "", description: "", completed: false });
  })

};
 //RemoveTodo tar bort men man får ändå fel meddelanden. har inte fel sökt detta mer. Får göra vid annat tillfälle. 
const removeTodo = (id) => {
fetch(`http://localhost:5213/todo/delete/${id}`, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json"
    },
  })
  .then(res => res.json())
  .then(() => {
    setList(list.filter(todo => todo.id !== id));
  })
}

const handelCheckbox = (e, id) => {
  const { name, value, checked } = e.target;
  setList(list.map(todo => {
    if (todo.id === id) {
      return { ...todo, [name]: name === 'completed' ? checked : value };
    }
    return todo;
  }));
};
const handelChange = (e) => {
  e.preventDefault();
  const { name, value } = e.target;
 
  setTodo((prev) =>
    (
      {...prev,
       
        [name]: value,
        completed : e.target.checked
      }
    ))
   
}



  return (
    <>
      <h1>Add todo</h1>
      <form onSubmit={handelSubmit}>
        <input
          type='text'
          name='title'
          value={todo.title}
          onChange={handelChange}
        />
        <input
          type='text'
          name='description'
          value={todo.description}
          onChange={handelChange}
        />
        <button>Add</button>
      </form>
      <ol>
       {list.map((todo, index) => {
      return (

        <li key={index}>
          <h3 >{todo.title} id: {todo.id}</h3>
          <h5 >{todo.description}</h5>
          <input 
          type='checkbox' 
          name='completed' 
          value={todo.completed}
          onChange={(e) =>handelCheckbox(e, todo.id)}
          />
          <button onClick={() => removeTodo(todo.id)}>Remove</button>
        </li>
         )})
        }
      </ol>


    </>
  );
}

export default App;
