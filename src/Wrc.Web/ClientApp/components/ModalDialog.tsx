import * as React from "react";

interface ModalDialogProps {
    show: boolean;
    onClose: any;
    children?: any;
    title: any;
}

export class ModalDialog extends React.Component<ModalDialogProps, {}> {
    close(e: any) {
        e.preventDefault();

        if (this.props.onClose) {
            this.props.onClose(e);
        }
    }

    render() {
        // Render nothing if the "show" prop is false
        if (!this.props.show) {
            return null;
        }

        return (
            <div className="modal is-active">
                <div className="modal-background" onClick={(e: any) => this.close(e)}></div>
                <div className="modal-card">
                    <header className="modal-card-head">
                        <p className="modal-card-title">{}</p>
                        <button className="delete" aria-label="close" onClick={(e: any) => this.close(e)}></button>
                    </header>
                    <section className="modal-card-body">
                        {this.props.children}
                    </section>
                    <footer className="modal-card-foot">
                    </footer>
                </div>
            </div>
        );
    }
}