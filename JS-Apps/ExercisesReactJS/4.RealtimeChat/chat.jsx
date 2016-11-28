let Chatbox = React.createClass({
    mixins: [ReactFireMixin],
    componentWillMount: function () {
        let ref = firebase.database().ref('messages');
        this.bindAsArray(ref, 'messages');
    },
    getInitialState: function () {
        return {msg: this.props.message, author: this.props.author};
    },
    handleMessageChange: function (event) {
        this.setState({msg: event.target.value});
    },
    handleAuthorChange: function (event) {
        this.setState({author: event.target.value});
    },
    handleMessageSend: function () {
        let body = JSON.stringify({
            'author' : this.state.author,
            'message' : this.state.msg,
            'timestamp' : Date.now()
        });

        $.post(config.databaseURL + 'messages.json', body ).catch(function (error) {
            console.dir(error)
        })
    },
    render: function () {
        let msgs = this.state.messages.map(x =>  {
            return  (
             <div className="messageContainer" key={x['.key']}>
                <div className="message">
                    Message: {x.message}
                </div>
                <div className="author">
                    Author: {x.author}
                </div>
            </div>)
        });
        return (
            <div id="chat">
                <fieldset>
                    <legend>Messages:</legend>
                    <div id="messages">
                        {msgs}
                    </div>
                </fieldset>
                <textarea id="message" value={this.state.msg} onChange={this.handleMessageChange}/>
                <input id="author" value={this.state.author} onChange={this.handleAuthorChange}/>
                <button onClick={this.handleMessageSend}>Post Message</button>
            </div>
        )
    }
});

class Message extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="messageContainer">
                <div className="message">
                    Message: {this.props.message}
                </div>
                <div className="author">
                    Author: {this.props.author}
                </div>
            </div>
        )
    }
}
