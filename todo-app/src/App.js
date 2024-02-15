import { useState, useEffect } from 'react';
import './App.css';

function App() {

  const [todo, setTodo] = useState({title: "", description: ""});
  const [list, setList] = useState([]);
  
const handelChange = (e) => {
  e.preventDefault();
  const { name, value } = e.target;
 
  setTodo((prev) =>
    (
      {...prev, 
        [name]: value
      }
    ))
}

  const handelSubmit = (e) => { 
    e.preventDefault();
    setList((prev) => [...prev,todo])
    setTodo(
    {title: "", description:""}
   )
   
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
          <h3 >{todo.title}</h3>
          <h5 >{todo.description}</h5>
        </li>
         )})
        }
      </ol>


    </>
  );
}

export default App;
