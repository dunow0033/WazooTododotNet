import React, { useState, useEffect } from "react";
import axios from 'axios';
import { useNavigate, Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

export default function AddTodo() {

    const [addTodoText, setAddTodoText] = useState('');

    const navigate = useNavigate();

    function addtodo(todoItem) {
        if(todoItem === '') {
            return;
        }

        //try {

            axios.post('http://localhost:5127/api/TodoItems', {
                description: todoItem
            }, {
                headers: 
                {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => {
                console.log('Todo added successfully:', response.data);
                setAddTodoText('');
                navigate("/");
            })
            .catch(error => {
                console.error('There was an error adding the item!', error);
              });
        //} catch(error) {
           // console.error('Error fetching items: ', error);
        //} catch()
    }

    return (
        <div className="container">
            <div className="row">
            <div className="col-2">
				<p><Link to="/" className="btn btn-outline-success">
                	<i className="bi bi-arrow-left-square-fill"></i> Back</Link>
            	</p>
			</div>
            <div className="col-6">
            <h2>Add a new Todo Item</h2>
            <input
                value={addTodoText}
                className="input"
                type="text"
                placeholder="Description"
                onChange={(e) => setAddTodoText(e.target.value)}
                onKeyDown={event => {
                    if(event.key === "Enter") {
                        addtodo(addTodoText)
                    }
                }}
                />
                {/*{errors.username && <p className="errorText">{errors.username}</p>}*/}
                <p><button className="btn btn-outline-success" onClick={() => addtodo(addTodoText)}>
                    <i className="bi bi-plus-square-fill">  Add Todo</i>
                </button>
                </p>
                </div>
            </div>
        </div>
    )
}