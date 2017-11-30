import * as React from "react";

import * as ReplaysAppState from "../../store/Replays";

interface ReplayCardProps {
    replay: ReplaysAppState.ReplayCardModel;
}

export class ReplayCard extends React.Component<ReplayCardProps, {}> {
    render() {
        const replay = this.props.replay;

        if (!replay)
            return null;

        return (
            <div>
                <div className="rc-game-info">
                    <div className="rc-minimap">
                        <img className="img-rounded" src="data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/PjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iMTQwIiBoZWlnaHQ9IjE0MCIgdmlld0JveD0iMCAwIDE0MCAxNDAiIHByZXNlcnZlQXNwZWN0UmF0aW89Im5vbmUiPjxkZWZzLz48cmVjdCB3aWR0aD0iMTQwIiBoZWlnaHQ9IjE0MCIgZmlsbD0iI0VFRUVFRSIvPjxnPjx0ZXh0IHg9IjQzLjUiIHk9IjcwIiBzdHlsZT0iZmlsbDojQUFBQUFBO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1mYW1pbHk6QXJpYWwsIEhlbHZldGljYSwgT3BlbiBTYW5zLCBzYW5zLXNlcmlmLCBtb25vc3BhY2U7Zm9udC1zaXplOjEwcHQ7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MTQweDE0MDwvdGV4dD48L2c+PC9zdmc+" />
                    </div>
                    <div className="rc-general-info">
                        <table className="table table-condensed">
                            <tbody>
                                <tr><td className="ewg-header-col">Map</td><td>{replay.mapName}</td></tr>
                                <tr><td className="ewg-header-col">Game mode</td><td>{replay.victoryConditionName}</td></tr>
                                <tr><td className="ewg-header-col">Version</td><td>{replay.gameVersion}</td></tr>
                                <tr><td className="ewg-header-col">Score to achieve</td><td>{replay.scoreLimit}</td></tr>
                                <tr><td className="ewg-header-col">Uploaded</td><td>{replay.uploadedAt}</td></tr>
                                <tr><td className="ewg-header-col">Game version</td><td>{replay.gameVersion}</td></tr>
                            </tbody>
                        </table>
                    </div>

                    <div className="pull-right">
                        <a className="btn btn-primary">
                            <span className="fa fa-download"></span> Download
                            </a>
                        <div className="clearfix"></div>
                        <p className="pull-right">Downloads: <span className="badge-notice">{replay.downloadCount}</span></p>
                    </div>
                </div>
                <div className="rc-players-info">
                    <div>
                        <h2 className="army-style-font">BLUEFOR</h2>

                    </div>
                    <div>
                        <h2>REDFOR</h2>

                    </div>
                </div>
            </div>
        );
    }
};