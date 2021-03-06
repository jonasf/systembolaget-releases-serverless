import os
import boto3
import json
from botocore.exceptions import ClientError


def get_releases(event, context):
    release_date = event['date']
    beverage_group = event['group']
    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    beverages = []
    try:
        response = table.get_item(
            Key={
                    'ReleaseDate': release_date,
                    'Group': beverage_group
                }
        )
    except ClientError as e:
        print(e.response['Error']['Message'])
    else:
        if 'Item' in response:
            data = response['Item']['Beverages']
            for item in data:
                beverages.append(json.loads(item))

    return {
        'data': json.dumps(beverages)
    }
