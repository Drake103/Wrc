import * as React from "react";
import { NavMenu } from "./NavMenu";

export class Layout extends React.Component<{}, {}> {
    render() {
        return (
            <div>
                <div className="container">
                    <NavMenu/>
                </div>

                <div className="container">
                    {this.props.children}
                </div>
            </div>);
    }
}