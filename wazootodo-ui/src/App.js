import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import MainList from './components/MainList';
import AddTodo from './components/AddTodo';
import EditTodo from './components/EditTodo';

function App() {
    return (
        <Router>
            <Routes>
                <Route exact path="/" element={<MainList />} />
                <Route path="/edittodo/:id" element={<EditTodo />} />
                <Route path="/addtodo" element={<AddTodo />} />
                {/*<Route path="*" element={<NotFound />} />*/}
            </Routes>
        </Router>
    )
}

export default App;
