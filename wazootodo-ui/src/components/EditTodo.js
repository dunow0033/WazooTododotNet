import React, { useState, useEffect } from "react";
import axios from 'axios';
import { useNavigate, useParams, Link } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

export default function EditTodo() {

    const [editTodoText, setEditTodoText] = useState('');
    const { id } = useParams();

    const navigate = useNavigate();

    useEffect(() => {
        axios.get(`http://localhost:5127/api/TodoItems/${id}`)
        .then(response => {
            setEditTodoText(response.data.description);
        })
        .catch(error => {
            console.error("There was an error fetching the item!", error);
        })
    }, [id]);

    function edittodo(todoItem, id) {
        if(todoItem === '') {
            return;
        }

        //try {

            axios.put(`http://localhost:5127/api/TodoItems/${id}`, {
                description: todoItem,
                id: id
            }, {
                headers: 
                {
                    'Content-Type': 'application/json'
                }
            })
            .then(response => {
                console.log('Todo updated successfully:', response.data);
                setEditTodoText('');
                navigate("/");
            })
            .catch(error => {
                console.error('There was an error editing the item!', error);
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
            <h2>Edit Todo Item #{id}</h2>
            <input
                value={editTodoText}
                name="editTodoText"
                className="input"
                type="text"
                onChange={(e) => setEditTodoText(e.target.value)}
                onKeyDown={event => {
                    if(event.key === "Enter") {
                        edittodo(editTodoText, id)
                    }
                }}
                />
                {/*{errors.username && <p className="errorText">{errors.username}</p>}*/}
                <p><button className="btn btn-outline-success" onClick={() => edittodo(editTodoText, id)}>
                    <i className="bi bi-plus-square-fill">  Update Todo</i>
                </button>
                </p>
                </div>
            </div>
        </div>
    )
}