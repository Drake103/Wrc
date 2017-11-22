import * as React from "react";
import { NavLink } from "react-router-dom";

export class NavMenu extends React.Component<{}, {}> {
    render() {
        return (
            <nav className="navbar is-white">
                <div className="navbar-brand">
                    <a className="navbar-item brand-text" href="../">
                        Bulma Blog
                    </a>
                    <div className="navbar-burger burger" data-target="navMenu">
                        <span></span>
                        <span></span>
                        <span></span>
                    </div>
                </div>
                <div id="navMenu" className="navbar-menu">
                    <div className="navbar-start">
                        <NavLink exact to={"/replays"} activeClassName="active" className="navbar-item">
                            <span className="glyphicon glyphicon-home"></span> Replays
                        </NavLink>
                        <NavLink to={"/counter"} activeClassName="active" className="navbar-item">
                            <span className="glyphicon glyphicon-education"></span> Counter
                        </NavLink>
                        <NavLink to={"/fetchdata"} activeClassName="active" className="navbar-item">
                            <span className="glyphicon glyphicon-th-list"></span> Fetch data
                        </NavLink>
                        <NavLink to={"/upload"} activeClassName="active" className="navbar-item">
                            <span className="glyphicon glyphicon-th-list"></span> Upload
                        </NavLink>
                    </div>
                </div>
            </nav>);
    }
}