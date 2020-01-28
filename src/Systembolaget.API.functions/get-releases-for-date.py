def get_releases(event, context):
    message = 'Release date: {}, beverage group: {}'.format(event['date'],
                                                            event['group'])

    return {
        'message': message
    }
