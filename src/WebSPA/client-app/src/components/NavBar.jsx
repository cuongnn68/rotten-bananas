import "./NavBar.css";
import React from "react"
import { useNavigate } from "react-router-dom";

class NavBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {isLogin: false}
        this.login = this.login.bind(this);
        this.logout = this.logout.bind(this);
        this.gotoSearchPage = this.gotoSearchMoviePage.bind(this);
    }
    // let isLogin = false;
    login() {
        this.setState({isLogin: true});
        console.log("status:" + this.state.isLogin);
    }
    logout() {
        this.setState({isLogin: false});
        console.log("status:" + this.state.isLogin);
    }
    gotoSearchMoviePage() {
        // useNavigate('/some/path');
    }

    render() {
        const isLogin = this.state.isLogin;
        return (
            <div>
                <div className="nav-bar">
                    <div className="pad" />
                    <Link className="logo" text="Rotten Bananas" route="/"/>
                    <Link className="link" text="Find your movie now !!!" route="/movie"/>
                    <div className="space" />
                    {
                        isLogin ? 
                        <div className="link" onClick={this.logout}>
                            Logout
                        </div>
                        :
                        <div className="link" onClick={this.login}>
                            Login
                        </div>
        
                    }
                    <div className="pad" />
        
                </div>
            </div>
        );
    }
}

function Link(props) {
    let navigate = useNavigate();
    return (
        <div className={props.className} onClick={() => navigate(props.route)}>
            {props.text}
        </div>
    );
}

export default NavBar;