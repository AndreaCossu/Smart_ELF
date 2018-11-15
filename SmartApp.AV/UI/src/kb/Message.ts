import * as KBEventReader from './KBEventReader';

/**
 * Builder class for KBEventReader messages.
 */
export class MessageBuilder {
	private method: string;
	private params: object = {};

	/**
	 * Set the current method
	 * @param op Operation to be performed
	 */
	public setMethod(op: KBEventReader.KB_OP): MessageBuilder {
		this.method = op;
		return this;
	}

	/**
	 * Adds a new parameter
	 * @param key The parameter identified
	 * @param value The values associated with the parameter
	 */
	public addParam(key: KBEventReader.PARAMS, value: any): MessageBuilder {
		this.params[key] = value;
		return this;
	}

	/**
	 * Build a new Message
	 */
	public build(): Message {
		return new Message(this.method, this.params);
	}
}

/**
 * This class represents a message that can be used to communicate with the KB.
 */
export class Message {
	constructor(private method: string, private params: object) {}

	public copy(params: any): Message {
		let m = new Message(this.method, this.params);

		for(var key in params) {
			m.params[key] = params[key];
		}

		return m;
	}
}