import '../App.css';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import { Button, Container, ListGroup } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

function MainList() {

  const navigate = useNavigate();
  const [items, setItems] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchTodoList();
  }, []);


function fetchTodoList() {
    axios.get('http://localhost:5127/api/TodoItems')
        .then(response => {
            setItems(response.data)
        })
        .catch(error => {
            setError(error);               
        })
}

function deletetodo(id) {
      axios.delete(`http://localhost:5127/api/TodoItems/${id}`, {
          id: id
      }, {
          headers: 
          {
              'Content-Type': 'application/json'
          }
      })
      .then(response => {
          console.log('Todo deleted successfully:', response.data);
          alert("Todo item " + )
          fetchTodoList();
      })
      .catch(error => {
          console.error('There was an error deleting the item!', error);
        });
}

const createTodo = () => {
    navigate("/addtodo");
}

  return (
    <>
      <div className='todo-list-item'>
                { items.length === 0 && <h3>Todo List is Empty</h3> }
                { items.length > 0 &&
                  items.map(item => (
                    <div key={item.id} className="todo-list-item">
                      <span>{item.id}&nbsp;&nbsp;&nbsp;
                        {item.description}&nbsp;&nbsp;&nbsp;
                        <a class="btn btn-info" href={`/edittodo/${item.id}`}><i class="bi bi-pencil-fill"></i>Edit</a>&nbsp;&nbsp;&nbsp;
                        <a class="btn btn-danger" onClick={() => deletetodo(item.id)}><i class="bi bi-trash-fill"></i>Delete</a></span>
                    </div>
                  ))
                }
                
        </div>
        <div className="row mt-3">
          <div className="col-auto">
            <a className="btn btn-outline-success" onClick={createTodo}> {/*href="/create-todo">*/}
            <i className="bi bi-pencil-square"></i>  Create a Todo</a>
          </div>
        </div>
    </>
  );
}

export default MainList;
