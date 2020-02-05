import os
import boto3
import json
from json import JSONEncoder
from boto3.dynamodb.conditions import Key
from botocore.exceptions import ClientError


class MyEncoder(JSONEncoder):
    def default(self, o):
        return o.__dict__


class Release:
    def __init__(self, date, count):
        self.date = date
        self.count = count


def get_releases(event, context):
    beverage_group = event['group']
    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    releases = []
    try:
        response = table.query(
            IndexName='GroupIndex',
            KeyConditionExpression=Key('Group').eq(beverage_group)
        )
    except ClientError as e:
        print(e.response['Error']['Message'])
    else:
        for item in response['Items']:
                releases.append(Release(item['ReleaseDate'],
                                str(item['NumberOfBeverages'])))

    return {
        'data': json.dumps(releases, cls=MyEncoder)
    }
