import React from "react";
import Router from "./Router";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import Navbar from "./components/NavBar";
import Footer from "./components/Footer";
import store from "./redux/store"; // חיבור ה- store
const App = () => {
  return (
    <BrowserRouter>
      <Provider store={store}>
        <Navbar />
        <div className="content">
          <Router />
        </div>
        <Footer />
      </Provider>
    </BrowserRouter>
  );
};

export default App;
