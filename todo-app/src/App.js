import { useState, useEffect } from 'react';
import './App.css';

function App() {

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
  })
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

//   const handelSubmit = (e) => { 
//     e.preventDefault();
//     setList((prev) => [...prev,todo])
//     setTodo((prev)=>(
//       {
//         id: prev.id+1, title: "", description:""
//       }
//       )
   
//    )
//     console.log(todo.id)
//   }


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
          onChange={handelChange}
          />
        </li>
         )})
        }
      </ol>


    </>
  );
}

export default App;
