import * as React from "react";

import { AllianceModel, PlayerModel } from "../../store/Replays";

interface AllianceDetailsProps {
    alliance: AllianceModel,
}

export class AllianceDetails extends React.Component<AllianceDetailsProps, {}> {
    render() {
        const alliance = this.props.alliance;

        return (
            <div>
                <h2>{alliance.name}</h2>
                <table className="table is-narrow">
                    <thead>
                        <tr>
                            <th className="faction-col"></th>
                            <th className="player-col">Player</th>
                            <th className="level-col">Level</th>
                            <th className="rank-col">Rank</th>
                            <th className="elo-col">ELO</th>
                            <th className="deck-col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {alliance.players.map((p: PlayerModel) =>
                            <tr key={p.id}>
                                <td>
                                    <span title={p.deck.nationName}></span>
                                    <span title={p.deck.specializationName}></span>
                                </td>
                                <td>{p.name}</td>
                                <td>{p.level}</td>
                                <td>{p.rank}</td>
                                <td>{p.elo}</td>
                                <td><button className="button is-small">Deck</button></td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>

        );
    }
};